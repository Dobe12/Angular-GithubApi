import { Component, OnInit } from '@angular/core';
import {WebApiServiceService} from './services/web-api-service.service';
import { Repositories} from './models/Repositories';

@Component({
  selector: 'app-github',
  templateUrl: './github.component.html',
  styleUrls: ['./github.component.css'],
  providers: [WebApiServiceService]
})
export class GithubComponent implements OnInit {
  repositoriesList: Repositories[] = [];
  constructor(private webapi: WebApiServiceService) { }

  ngOnInit() {
    this.webapi.getLastResponsedRepositories().subscribe(data => {this.repositoriesList = data; console.log(data); },
      err => console.log('HTTP error', err.message));
  }
  getRepositories(term: string) {
    this.webapi.getRepositories(term).subscribe(data => {this.repositoriesList = data; console.log(data); },
      err => console.log('HTTP error', err.message));
  }
}
