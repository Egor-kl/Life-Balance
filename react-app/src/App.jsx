import React from 'react';
import { store } from './actions/store';
import { Provider } from 'react-redux';
import { ToastProvider } from "react-toast-notifications";
import {BrowserRouter, Route } from 'react-router-dom';
import CreateDiary from './components/Diary/Create';
import Header from "./components/Home/Header.jsx";
import Footer from "./components/Home/Footer";
import Content from "./components/Home/Content";
import Profile from "./components/Profile/Profile";
import InfoDiary from './components/Diary/Info';
import EditDiary from './components/Diary/Edit';
import Login from './components/Account/Login';
import Registration from "./components/Account/Registration";

function App(){
    return (
        <BrowserRouter>
            <Provider store={store}>
                <ToastProvider autoDismiss={true}>
                    <Header />
                    <Route exact path='/' component={Content} />
                    <Route path='/profile' component={Profile}/>
                    <Route path='/diary/create' component={CreateDiary} />
                    <Route path='/diary/info/:id' component={InfoDiary} />
                    <Route path='/diary/edit/:id' component={EditDiary}/>
                    <Footer />
                </ToastProvider>
            </Provider>
        </BrowserRouter>
    );
}

export default App