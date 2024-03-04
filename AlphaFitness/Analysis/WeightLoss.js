const ctx3 = document.getElementById('weightLoss');


new Chart(ctx3, {
    type: 'line',
    data: {
        labels: ['Jan', 'Feb', 'Mac', 'Apr', 'May', 'Jun', 'Jul', 'Aug'],
        datasets: [{
            label: 'Monthly Weight loss',
            data: [81, 79, 75, 73, 70, 72, 68, 65],
            borderWidth: 2,
            fill: false,
            borderColor: 'rgb(75, 192, 192)',
            tension: 0.3
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: false
            }
        }
    }
});