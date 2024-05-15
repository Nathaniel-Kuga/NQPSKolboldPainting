import { AddPaintDto } from "./addPaintDto";

console.log('addPaint.ts loaded');
const table = document.getElementById('paintTable');
let rowData: string[] = [];

table.addEventListener('click', (event) => {
    // let row = event.target.closest('tr');
    let row = (event.target as Element).closest('tr');
    // If a row was clicked
    if (row) {
        // Get the cells of the clicked row
        let cells = row.cells as HTMLCollection;

        // Extract the text from each cell
        rowData = Array.from(cells).map(cell => (cell as HTMLElement).innerText);

        // Log the row data
        console.log(rowData);
    }
});
const addPaintForm = document.getElementById('addPaintForm');

addPaintForm.addEventListener('submit', (event) => {
    event.preventDefault();
    const selectedList = document.getElementById('listName') as HTMLSelectElement;
    // const addPaintDto = new AddPaintDto(rowData[0], rowData[1], selectedList.value);
    // console.log(addPaintDto);
    const paintDto = {
        name: rowData[0],
        brand: rowData[1],
        list: selectedList.value
    };
    console.log(paintDto);
    const s: string = 'Hello';
    $.ajax({
        url: '/api/AddPaint/AddPaintToCollection',
        type: 'POST',
        data: JSON.stringify(paintDto),
        contentType: 'application/json',
        success: function (response) {
            //console.log(response);
            alert(response);
        },
        error: function (response) {
            console.log(response);
        }
    });

    // // Perform any necessary processing or API calls

    // // Reset the form
    // addPaintForm.reset();
});

// $('#testbtn').on('click', () => {
//     alert('test');
//     $.ajax({
//         url: '/api/AddPaint/AddPaintToCollection',
//         type: 'POST',
//         success: function(response) {
//             // Handle the response here
//             console.log(response);
//         },
//         error: function(error) {
//             // Handle error here
//             console.error(error);
//         }
//     });
// }); 