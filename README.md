# InvestmentProjection
A web application to show investment projection depending on input

## Technologies
Web Application: **.NET Core using Razor**

Data visualisation (graph): [**Chart.js**](https://www.chartjs.org/)

### Data visualisation framework comparison
#### D3.js
Pros: Feature packed, lots of options for customization, can integrate with a lot of frameworks
Cons: Said to have a steep learning curve, documentation may be outdated

#### Chart.js
Pros: Lots of features, open-source with good development support, good documentation
Cons: Does not seem to be able to integrate with many other frameworks, may be slow to render charts

#### CanvasJS
Pros: Lots of features, well documented, easy to use
Cons: Requires a licence

#### Verdict
Chart.js due to the relatively ease of use compared to D3.js and the open-source factor of the framework

Research was also done to see whether Chart.js can produce the visualisation required.

[POC](https://jsfiddle.net/yo4cmqtL/)


## Milestones
### Milestone 1 - Working page with input boxes
#### Tasks
- Create .NET Core solution
- Create a GET endpoint with parameters related to the input values specified
- Return a 200 response if inputs are valid
- Return a 400 response if inputs are not valid or missing
- Add input boxes onto front-end
- Implement ajax call to contact the GET endpoint with the values from the input boxes
- Display success or fail within the front-end depending on what is returned

### Milestone 2 - Simple graph displayed
#### Tasks
- Create a handler to calculate the projections
- Use the calculation handler in the GET endpoint and return the values
- Add Chart.js into the solution
- Create a graph on the front-end using the returned values
- Graph should show
  - Time (years) on X-axis
  - Value (£) on Y-axis
  - Marker lines for Target Amount and End Timescale
  - Graph line for Total Invested

### Milestone 3 - Coloured regions on graph
#### Tasks
- Update handler to calculate growth figures
- Update front-end to use the growth figures to display coloured regions on the graph
