import { Button } from "@mui/material";
import { PartOfSpeechInsert } from "../../../../types/requests";
import usePartOfSpeechCreate from "../../../../hooks/queries/usePartOfSpeechCreate";
import { useEffect } from "react";

type Props = {
  request: PartOfSpeechInsert;
  onLoading?: () => void;
  onLoadingFinished?: () => void;
};

export default function PartOfSpeechSubmitButton({
  request,
  onLoading,
  onLoadingFinished,
}: Props) {
  const { mutate, isLoading } = usePartOfSpeechCreate();

  useEffect(() => {
    if (isLoading && onLoading) onLoading();
    if (!isLoading && onLoadingFinished) onLoadingFinished();
  }, [isLoading]);

  function handleSubmit() {
    mutate(request);
  }

  return (
    <Button disabled={isLoading} onClick={handleSubmit}>
      Add Part of Speech
    </Button>
  );
}
