document.addEventListener('DOMContentLoaded', function () {
    

    document.getElementById('plantForm').addEventListener('submit', function (event) {
        event.preventDefault();

        const Name = document.querySelector('#name').value;
        const Type = document.querySelector('#type').value;
        const Water = parseFloat(document.querySelector('#water').value);
        const Frequency = parseInt(document.querySelector('#frequency').value);

        const newPlant = { Name, Type, Water, Frequency };
        
        sendPlant(newPlant)
        console.log(newPlant)
       
    });

    document.getElementById("clearBtn").addEventListener("click", function () {
        fetch('http://localhost:5116/api/plant', {
            method: 'DELETE'
        }).then(() => renderSchedule());
    });
});

function sendPlant(plant){
    fetch('http://localhost:5116/api/plant', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(plant)
    }) .then(resp => {
        console.log('create: ' + resp)
        if (resp.status === 200) {
            renderSchedule()
        } else {
            resp.text().then(console.warn)
        }
    })
    .catch(error => console.log(error))

   document.getElementById('plantForm').reset();

}

//asdasdasd


async function renderSchedule() {
    const response = await fetch('http://localhost:5116/api/plant/schedule')
    const data = await response.json()
    console.log(data)

    
    const schedule = data.weeklySchedule;
    const waterUsage = data.weeklyWaterConsumption;
    const workload = data.dailyWorkload;

    const tbody = document.getElementById("table-target");
    tbody.innerHTML = "";

    const days = ["Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek", "Szombat", "Vasárnap"];

    for (const plantName in schedule) {
        const row = document.createElement("tr");

        
        const nameCell = document.createElement("td");
        nameCell.textContent = plantName;
        row.appendChild(nameCell);

        
        days.forEach(day => {
            const cell = document.createElement("td");
            if (schedule[plantName].includes(day)) {
                cell.textContent = `${(waterUsage[plantName] / schedule[plantName].length).toFixed(2)} ml`;
            } else {
                cell.textContent = "";
            }
            row.appendChild(cell);
        });

        
        const totalCell = document.createElement("td");
        totalCell.textContent = `${waterUsage[plantName].toFixed(2)} ml`;
        row.appendChild(totalCell);

        tbody.appendChild(row);
    }

    highlightBusyDays(workload);
}

function highlightBusyDays(workload) {
    const max = Math.max(...Object.values(workload));
    const headers = document.querySelectorAll("thead th");
    const days = ["Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek", "Szombat", "Vasárnap"];

    days.forEach((day, index) => {
        const count = workload[day];
        if (count === max && max > 0) {
            headers[index + 1].style.backgroundColor = "#f9caca";
        } else {
            headers[index + 1].style.backgroundColor = "";
        }
    });
}
