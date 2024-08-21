import React, { createContext, ReactNode, useState } from "react";

export const LoginContext = createContext({
  isLoggedIn: false,
  isAdmin: false,
  logIn: () => {},
  logOut: () => {},
  username: "",
  password: "",
  userId: 0,
  saveUsernameToContext: (username: string) => {},
  savePasswordToContext: (password: string) => {},
  saveUserIdToContext: (userId: number) => {},
  encodedHeader: "",
  saveEncodedHeaderToContext: () => {}
});

interface LoginManagerProps {
  children: ReactNode;
}

export function LoginManager(props: LoginManagerProps): JSX.Element {
  const [loggedIn, setLoggedIn] = useState(true);

  const [contextUsername, setContextUsername] = useState("");
  const [contextPassword, setContextPassword] = useState("");
  const [encodedHeader, setEncodedHeader] = useState("");
  const [contextUserId, setContextUserId] = useState(0);

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

  function saveEncodedHeaderToContext() {
    setEncodedHeader(btoa(`${contextUsername}:${contextPassword}`));
  }

  function saveUserIdToContext(userId: number) {
    setContextUserId(userId);
  }

  const context = {
    isLoggedIn: loggedIn,
    isAdmin: loggedIn,
    logIn: logIn,
    logOut: logOut,
    username: contextUsername,
    password: contextPassword,
    userId: contextUserId,
    saveUsernameToContext: saveUsernameToContext,
    savePasswordToContext: savePasswordToContext,
    saveUserIdToContext: saveUserIdToContext,
    encodedHeader: encodedHeader,
    saveEncodedHeaderToContext: saveEncodedHeaderToContext
  };

  return (
    <LoginContext.Provider value={context}>
      {props.children}
    </LoginContext.Provider>
  );
}
