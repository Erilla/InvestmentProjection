// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var chart;

function createChart(labels, totalInvestmentData, targetValue, timeScale)
{
    if (chart) chart.destroy();

    var totalInvestment = {
        label: "Total Investment",
        fill: false,
        lineTension: 0.1,
        backgroundColor: "rgba(75,192,192,0.4)",
        borderColor: "rgba(75,192,192,1)",
        data: totalInvestmentData,
    };

    var config = {
        type: 'line',
        data: {
            labels: labels,
            datasets: [totalInvestment]
        },
        options: {
            responsive: true,
            scales: {
                x: {
                    type: "linear",
                    display: true,
                    ticks: {
                        stepSize: 1,
                        beginAtZero: true
                    },
                    title: {
                        display: true,
                        text: "Time (Years)"
                    }
                },
                y: {
                    display: true,
                    title: {
                        display: true,
                        text: "Value (£)"
                    }
                }
            },
            elements: {
                point: {
                    radius: 0
                }
            },
            plugins: {
                annotation: {
                    annotations: [
                        {
                            type: 'line',
                            scaleID: 'y',
                            borderWidth: 3,
                            borderColor: 'red',
                            value: targetValue,
                            label: {
                                content: 'Target Value',
                                enabled: true
                            }
                        },
                        {
                            type: 'line',
                            scaleID: 'x',
                            borderWidth: 3,
                            borderColor: 'green',
                            value: timeScale,
                            label: {
                                content: 'End Timescale',
                                enabled: true
                            }
                        }
                    ]
                }
            },
        }
    };

    var ctx = document.getElementById("investmentChart").getContext("2d");
    chart = new Chart(ctx, config);
}