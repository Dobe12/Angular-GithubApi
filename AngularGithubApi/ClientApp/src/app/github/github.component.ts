import { Component, OnInit } from '@angular/core';
import {WebApiServiceService} from '../web-api-service.service';
import { Card} from '../Classes/Card';

@Component({
  selector: 'app-github',
  templateUrl: './github.component.html',
  styleUrls: ['./github.component.css'],
  providers: [WebApiServiceService]
})
export class GithubComponent implements OnInit {
  cardList: Card[] = [];
  constructor(private webapi: WebApiServiceService) { }

  ngOnInit() {
    this.webapi.getLastRequest().subscribe(data => {this.cardList = data; console.log(data); },
      err => console.log('HTTP error', err.message));
  }
  getResponse(request: string) {
    this.webapi.getResponse(request).subscribe(data => {this.cardList = data; console.log(data); },
      err => console.log('HTTP error', err.message));
  }
}
