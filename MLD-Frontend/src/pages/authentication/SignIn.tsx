import { Button, FormGroup, TextField } from "@mui/material";
import { useRef } from "react";
import useSignIn from "../../hooks/queries/useSignIn";
import ValidationItemsDisplay from "../../components/ValidationItemsDisplay";

export default function SignIn(){
    const userNameRef = useRef(null);
    const passwordRef = useRef(null);
    const passwordConfirmRef = useRef(null);
    const emailRef = useRef(null);
    const emailConfirmRef = useRef(null);
    
    const {mutateAsync: requestSignin, data} = useSignIn();

    async function handleLogin(): Promise<void> {
        const userName = userNameRef.current?.value;
        const password = passwordRef.current?.value;
        const passwordConfirm = passwordConfirmRef.current?.value;
        const email = emailRef.current?.value;
        const emailConfirm = emailConfirmRef.current?.value;

        if([userName,
            password,
            passwordConfirm,
            email,
            emailConfirm].some(item => !item))
            return;

        const response = await requestSignin({
            userName,
            password,
            passwordConfirm,
            email,
            emailConfirm
        })

        console.log(response)
    }

    console.log(data)

    return <FormGroup className="flex flex-col gap-4">
        {data?.data.errors.length ? <ValidationItemsDisplay items={data.data.errors} style="error" /> : null}
        <TextField inputRef={userNameRef} label={"Username"} />
        <TextField inputRef={passwordRef} type="password" label={"password"} />
        <TextField inputRef={passwordConfirmRef} type="password" label={"Confirm password"} />
        <TextField inputRef={emailRef} label={"Email"} />
        <TextField inputRef={emailConfirmRef} label={"Confirm email"} />

        <Button onClick={handleLogin}>Sign in</Button>
    </FormGroup>
}