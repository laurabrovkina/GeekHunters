import React from 'react';
import { Route } from 'react-router-dom';
import CandidateList from './components/CandidateList';

export default class App extends React.PureComponent {
  static displayName = App.name;

  render () {
    return (
      <Route exact path='/' component={CandidateList} />
    );
  }
}
