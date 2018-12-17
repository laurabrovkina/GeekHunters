import React from 'react';
import { Route } from 'react-router-dom';
import CandidateList from './components/CandidateList';
import './App.css';

export default class App extends React.PureComponent {
  static displayName = App.name;

  render () {
    return <div className='App'>
      <Route exact path='/' component={CandidateList} />
    </div>;
  }
}
