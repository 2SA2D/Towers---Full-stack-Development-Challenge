// import the ViewChild 
import { Component, ViewChild } from '@angular/core';
// import the service of table
import { TableService } from './table.service';
// import paginator
import {MatPaginator} from '@angular/material/paginator'
// import Sort 
import {MatSort} from '@angular/material/sort'
// import Table data Source
import { MatTableDataSource } from '@angular/material/table';
// import Chartjs
import {Chart, registerables} from 'node_modules/chart.js'
// regester the chart
Chart.register(...registerables);
// Create the interface of data from api
export interface TowersData{
  tower_id: string;
  operator: string;
  address : string;
  height  : string;
  tower_type : string;
  latitude  : string;
  longitude : string;
  technology : string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Towers';
  // define the the table header
  _columns: string[] = ['tower_id', 'operator','address','height','tower_type', 'latitude','longitude', 'technology']
  // define the data source 
  data_Source!: MatTableDataSource<TowersData>
  // define the paginator
  @ViewChild(MatPaginator) paginator! : MatPaginator
  // define the sort
  @ViewChild(MatSort) sort! : MatSort
  // create a variable to recive data from api
  tower:any;
  // define a variable to count the total of 2G in technology column
  count2G:any = 0;
  // define a variable to count the total of 3G in technology column
  count3G:any= 0;
  // define a variable to count the total of 4G in technology column
  count4G:any= 0;
  // define a variable to count the total of 5G in technology column
  count5G:any= 0;
  

  // constract the service to get the data
  constructor(private service: TableService){
    // lambda expression to make operation on the data
    this.service.getData().subscribe(data => {
      // display all data in console
      console.log(data)
      // assign the data to the variable
      this.tower = data
      // create the object of table data source
      this.data_Source = new MatTableDataSource(this.tower)
      // control the shown data in the table
      this.data_Source.paginator = this.paginator
      // sort the data table
      this.data_Source.sort = this.sort
    })

    
  }
  // create a fliter function with a event
  filter(event: Event){
    // recive the input data
      const filter_Value = (event.target as HTMLInputElement).value;
      // lowercase the input data and remove any spaces
      this.data_Source.filter = filter_Value.trim().toLowerCase()
      // display the first page of table after make the paginator
      if (this.data_Source.paginator){
        this.data_Source.paginator.firstPage()
      }
  }

  // loading function
  ngOnInit(): void{
    // define the service to get the data
      this.service.getData().subscribe(data => {
      this.tower = data
      // check if null
      if (this.tower != null){
        // for loop to count different technology type
        for(let i=0; i<this.tower.length; i++){
          if(this.tower[i].technology == "2G"){
            this.count2G = this.count2G +1;
          }
          if(this.tower[i].technology == "3G"){
            this.count3G = this.count3G +1;
          }
          if(this.tower[i].technology == "4G"){
            this.count4G = this.count4G +1;
          }
          if(this.tower[i].technology == "5G"){
            this.count5G = this.count5G +1;
          }
        }
        // call the function
        this.JsChart(this.count2G,this.count3G,this.count4G,this.count5G);
      }
      
    });

   
  }
  // create the fuction of chartjs
  JsChart(TwoG: any, ThreeG:any,FourG:any,FiveG:any){
    // define the chart with id
    const myChart = new Chart("Barchart",{
      // define the bar chart
      type: 'bar',
      data: {
        // define lables
        labels: ['2G','3G','4G','5G'],
        datasets: [{
          label: 'Technology',
          // assign data to chart
          data: [TwoG,ThreeG,FourG,FiveG],
          // set background color
          backgroundColor: [
            'rgba(255,99,132,0,2)',
            'rgba(54,162,235,0,2)',
            'rgba(255,206,86,0,2)',
            'rgba(75,192,192,0,2)',
            'rgba(151,102,255,0,2)',
            'rgba(255,159,64,0,2)'
          ],
          // set border color
          borderColor: [
            'rgba(255,99,132,1)',
            'rgba(54,162,235,1)',
            'rgba(255,206,86,1)',
            'rgba(75,192,192,1)',
            'rgba(151,102,255,1)',
            'rgba(255,159,64,1)'
          ],
          // set set border width
          borderWidth: 1
        }]
      },
      options: {
        scales: {
          y: {
            beginAtZero: true
          }
        },
        plugins: {
          legend: {
            // display legend on the top position
            position: 'top',
          },
          title: {
            display: true,
            text: 'Towers Technology Bar Chart'
          }
        },
        // make the chart responsive
        responsive: true,
      }
    });
  }
}
