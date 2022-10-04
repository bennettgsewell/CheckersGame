import React, { Component } from 'react';
import Tile from './Tile';
import Board from './Board';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
            <Board />
      </div>
    );
  }
}
