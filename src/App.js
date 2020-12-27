import './App.css';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import HomePage from './Components/HomePage';
import React from 'react';
import EditRoom from './Components/EditRoom';
import WiewRoom from './Components/WiewRoom';



function App() {
    return (

            <Router>

                <Switch>
                    <Route path="/editroom" component={EditRoom} />
                    <Route path="/wiewroom" component={WiewRoom} />
                    <Route path="/" component={HomePage} />
                </Switch>
            </Router>

    );
}

export default App;
