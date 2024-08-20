﻿import React, {useContext, useState} from "react";
import {Page} from "../Page/Page";
import {SearchInput} from "../../Components/SearchInput/SearchInput";
import {fetchUsers} from "../../Api/apiClient";
import {UserCard} from "../../Components/UserCard/UserCard";
import {InfiniteList} from "../../Components/InfititeList/InfiniteList";
import "./Users.scss";
import { LoginContext } from "../../Components/LoginManager/LoginManager";

export function Users(): JSX.Element {
    const loginContext = useContext(LoginContext);

    const [searchTerm, setSearchTerm] = useState("");
    
    function getUsers(page: number, pageSize: number) {
        return fetchUsers(searchTerm, page, pageSize, loginContext.encodedHeader);
    }
    
    return (
        <Page containerClassName="users">
            <h1 className="title">Users</h1>
            <SearchInput searchTerm={searchTerm} updateSearchTerm={setSearchTerm}/>
            <InfiniteList fetchItems={getUsers} renderItem={user => <UserCard key={user.id} user={user}/>}/>
        </Page>
    );
}