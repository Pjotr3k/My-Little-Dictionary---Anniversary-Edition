using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Model;
using System.Runtime.CompilerServices;

namespace My_Little_Dictionary___Anniversary_Edition.Mappers
{
    public static class ValidationMapper
    {
        public static ValidationResponse<TResult> Transform<TSource, TResult>(this ValidationResponse<TSource> source, Func<TSource, TResult> selector)
        {
            ValidationResponse<TResult> result = new ValidationResponse<TResult>();
            result.MergeValidation(source);

            if (source.Result != null)
            {
                try
                {
                    result.Result = selector(source.Result);
                }
                catch (Exception ex)
                {
                    result.Errors.Add(ex.Message);
                }
            }

            return result;
        }

        public static ValidationResponse<List<PartOfSpeechDTO>> ToDTO(this ValidationResponse<List<PartOfSpeech>> source)
        {
            ValidationResponse<List<PartOfSpeechDTO>> result = new ValidationResponse<List<PartOfSpeechDTO>>();
            result.MergeValidation(source);

            if (source.Result != null)
                result.Result = source.Result
                    .Select(item => new PartOfSpeechDTO(item))
                    .ToList();

            return result;
        }

        public static ValidationResponse<FormDTO> ToDTO(this ValidationResponse<Form> source)
        {
            ValidationResponse<FormDTO> result = new ValidationResponse<FormDTO>();
            result.MergeValidation(source);

            if (source.Result != null)
                result.Result = new FormDTO(source.Result);

            return result;
        }


        public static ValidationResponse<List<FormDTO>> ToDTO(this ValidationResponse<List<Form>> source)
        {
            ValidationResponse<List<FormDTO>> result = new ValidationResponse<List<FormDTO>>();
            result.MergeValidation(source);

            if (source.Result != null)
                result.Result = source.Result
                    .Select(item => new FormDTO(item))
                    .ToList();

            return result;
        }

    }
}
