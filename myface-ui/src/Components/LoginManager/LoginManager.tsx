import React, { createContext, ReactNode, useState } from "react";

export const LoginContext = createContext({
  isLoggedIn: false,
  isAdmin: false,
  logIn: () => {},
  logOut: () => {},
  username: "",
  password: "",
  saveUsernameToContext: (username: string) => {},
  savePasswordToContext: (password: string) => {},
  encodedHeader: ""
});

interface LoginManagerProps {
  children: ReactNode;
}

export function LoginManager(props: LoginManagerProps): JSX.Element {
  const [loggedIn, setLoggedIn] = useState(true);

  const [contextUsername, setContextUsername] = useState("");
  const [contextPassword, setContextPassword] = useState("");

  function logIn() {
    setLoggedIn(true);
  }

  function logOut() {
    setLoggedIn(false);
  }

  function saveUsernameToContext(username: string) {
    setContextUsername(username);
  }

  function savePasswordToContext(password: string) {
    setContextPassword(password);
  }

  const context = {
    isLoggedIn: loggedIn,
    isAdmin: loggedIn,
    logIn: logIn,
    logOut: logOut,
    username: contextUsername,
    password: contextPassword,
    saveUsernameToContext: saveUsernameToContext,
    savePasswordToContext: savePasswordToContext,
    encodedHeader: btoa(`${contextUsername}:${contextPassword}`)
  };

  return (
    <LoginContext.Provider value={context}>
      {props.children}
    </LoginContext.Provider>
  );
}
