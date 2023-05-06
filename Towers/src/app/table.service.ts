import { Injectable } from '@angular/core';
// import Http Client
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})

export class TableService {
  // define the api
  // the original api
  //private base_URL = "https://byanat.wiremockapi.cloud/api/v3/towers"
  // the local api with swagger
  //private base_URL = "https://localhost:7153/api/Tower/GetAll"
  // the local api without swagger
  private base_URL = "https://localhost:44364/api/tower"
  // constract the constructor 
  constructor(private http:HttpClient) { }
  // create method to return the data from api
  getData(){
    return this.http.get(this.base_URL);
  }
}
