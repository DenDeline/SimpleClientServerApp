import React from 'react';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
import DisplayInfo from './DisplayInfo';

const App = () => (
    // <BrowserRouter basename="/home/">
    // <>
    //     <Switch>
    //         <Route exact path="/" component={DisplayInfo}/>
    //         <Route exact path="/:activeUser" component={DisplayInfo}/>
    //     </Switch>
    // </>
    // </BrowserRouter>
    <DisplayInfo/>
)

export default App;