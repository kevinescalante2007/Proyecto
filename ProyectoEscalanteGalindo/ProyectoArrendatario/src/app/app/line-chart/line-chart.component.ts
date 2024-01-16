// import { Component, OnInit } from '@angular/core';
// import { Chart, ChartType } from 'chart.js/auto';

// @Component({
//   selector: 'app-line-chart',
//   templateUrl: './line-chart.component.html',
//   styleUrl: './line-chart.component.css'
// })
// export class LineChartComponent implements OnInit{
  
//   public chart: Chart;


//   ngOnInit(): void {
//    // datos
//    const data = {
//     labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
//     datasets: [{
//       label: 'My First Dataset',
//       data: [65, 59, 80, 81, 56, 55, 40],
//       fill: false,
//       borderColor: 'rgb(75, 192, 192)',
//       tension: 0.1
//     }]
//   };

//   // Creamos la gráfica
//   this.chart = new Chart("chart", {
//     type: 'line' as ChartType, // tipo de la gráfica 
//     data // datos 
// })
//   }

// }

import { Component, OnInit } from '@angular/core';
import { Chart, ChartType } from 'chart.js/auto';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent implements OnInit {
  
  public chart: Chart;

  ngOnInit(): void {
    // Supongamos que obtienes estos datos de tu base de datos
    const nombresApartamentos = ['Ficoa', 'Pinllo', 'Huachi', 'Centro', 'Izamba'];
    const preciosApartamentos = [1200, 1500, 1300, 1600, 1800];

    const data = {
      labels: nombresApartamentos,
      datasets: [{
        label: 'Precios de Apartamentos',
        data: preciosApartamentos,
        fill: false,
        borderColor: 'rgb(75, 192, 192)',
        tension: 0.1
      }]
    };

    this.chart = new Chart("chart", {
      type: 'line' as ChartType,
      data
    });
  }
}
