const plants = [];

document.addEventListener('DOMContentLoaded', function () {
    const savedPlants = JSON.parse(localStorage.getItem("plants")) || [];
    plants.push(...savedPlants);
    renderPlants();

    document.getElementById('plantForm').addEventListener('submit', function(event) {
        event.preventDefault();

        let name = document.querySelector('#name').value;
        let type = document.querySelector('#type').value;
        let water = parseFloat(document.querySelector('#water').value);
        let frequency = parseInt(document.querySelector('#frequency').value);

        let newPlant = { name, type, water, frequency };
        plants.push(newPlant);
        console.log(plants)

        localStorage.setItem("plants", JSON.stringify(plants));

        renderPlants();
        document.getElementById("plantForm").reset();
    });
});

function renderPlants() {
    const tbody = document.getElementById("table-target");
    tbody.innerHTML = "";

    plants.forEach((plant) => {
        const row = document.createElement("tr");

        // Növény neve
        const nameCell = document.createElement("td");
        nameCell.textContent = plant.name;
        row.appendChild(nameCell);

        // Heti öntözési terv (7 napra)
        let totalWater = 0;
        for (let i = 0; i < 7; i++) {
            const cell = document.createElement("td");
            if (i % plant.frequency === 0) {
                cell.textContent = `${plant.water} ml`;
                // cell.style.backgroundColor = "#d0f0c0"; 
                totalWater += plant.water;
            } else {
                cell.textContent = "";
                // cell.style.backgroundColor = "#ffcccc";
            }
            row.appendChild(cell);
        }

        // Heti összes vízfogyasztás
        const totalCell = document.createElement("td");
        totalCell.textContent = `${totalWater} ml`;
        row.appendChild(totalCell);

        // Sor hozzáadása a táblázathoz
        tbody.appendChild(row);
    });


    document.getElementById("clearBtn").addEventListener("click", function () {
        plants.length = 0;
        localStorage.removeItem("plants");
        document.getElementById("table-target").innerHTML = "";
    });
}


