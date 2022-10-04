import React, { Component } from 'react';

export class Tile extends Component {
    constructor(props) {
        super();

        /*
            Empty = 0,
            P1 = 1,
            P2 = 2,
            P3 = 3,
            P4 = 4,
            P5 = 5,
            P6 = 6,
            Blocked = 255,
        */


        this.state = {
            player: props.player
        };
    }

    render() {
        let player = this.state.player;

        // No Tile to Render
        if (player === 255)
            return null;

        let src = "Dot.png";

        return (
            <img src={src} className="tile" />
        );
    }
}

export default Tile;