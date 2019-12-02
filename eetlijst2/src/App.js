import React from 'react';
import logo from './logo.svg';
import './App.css';
import Login from './Login';  
import Reg from './Reg';  
import Dashboard from './Dashboard';  
import { BrowserRouter as Router, Switch, Route, Link } from 'react-router-dom';   


class App extends React.Component {  
  render(){
  return (  
    <Router>    
      <div className="container">        
        <Switch>    
          <Route exact path='/Login' component={Login} />    
          <Route path='/Signup' component={Reg} />    
       
        </Switch>    
        <Switch>  
        <Route path='/Dashboard' component={Dashboard} />    
        </Switch>  
      </div>    
    </Router>   
  );  }
}  
  
export default App;  