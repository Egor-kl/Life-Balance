import React from 'react';
import { render } from 'react-dom';
import {store } from './actions/store';
import { Provider } from 'react-redux';
import Diary from './components/Diary';

function App(){
    return (
        <Provider store={store}>
            <Diary />
        </Provider>
    );
}

export default App