import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true, recipeName: "Not Set yet", loading2: true };
  }

  componentDidMount() {
      this.populateWeatherData();
      this.getRecipeName();
  }

  static renderForecastsTable(forecasts) {
    return (
        <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
            <tr key={forecast.date}>
              <td>{forecast.date}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.summary}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
          : FetchData.renderForecastsTable(this.state.forecasts);

      let contents2 = this.state.loading2
          ? <p><em>Loading...</em></p>
          : <p>{this.sate.recipeName}</p>;

    return (
      <div>
            <h1 id="tabelLabel" >Weather forecast</h1>
            <button onClick={() => this.getRecipeName()}>Fetch Recipe Name</button>
            {contents2}
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('weatherforecast');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
    }

    async getRecipeName() {
        const response = await fetch('weatherforecast/GettingRecipeName');
        var data = await response.json();
        console.log(JSON.stringify(data));
        this.setState({ recipeName: JSON.stringify(data), loading2: false });
    }
}
