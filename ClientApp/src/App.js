import React from 'react';
import { Route, Switch } from 'react-router-dom';
import './App.css';
import CandidateList from './components/CandidateList';
import CandidateForm from './components/CandidateForm';

export default class App extends React.PureComponent {
  static displayName = App.name;

  render () {
    return <div className='App'>
      <Switch>
        <Route exact path='/' component={CandidateList} />
        <Route path='/add' component={CandidateForm} />
      </Switch>
    </div>;
  }
}
