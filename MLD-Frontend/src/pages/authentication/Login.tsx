import { Button, FormGroup, TextField } from "@mui/material";
import useLogin from "../../hooks/queries/useLogin";
import { useRef } from "react";
import ValidationItemsDisplay from "../../components/ValidationItemsDisplay";

export default function Login(){
    const loginRef = useRef(null);
    const passwordRef = useRef(null);
    
    const {mutateAsync: requestLogin, data} = useLogin();

    async function handleLogin(): Promise<void> {
        const response = await requestLogin({
            userName: loginRef.current?.value || "",
            password: passwordRef.current?.value || ""
        })
    }

    return <FormGroup className="flex flex-col gap-4">
        {data?.data.errors.length ? <ValidationItemsDisplay items={data.data.errors} style="error" /> : null}

        <TextField inputRef={loginRef} label={"login"} />
        <TextField inputRef={passwordRef} type="password" label={"password"} />
        <Button onClick={handleLogin}>Login</Button>
    </FormGroup>
}