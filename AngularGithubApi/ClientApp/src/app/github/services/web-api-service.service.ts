import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Repositories} from '../models/Repositories';

@Injectable({
  providedIn: 'root'
})
export class WebApiServiceService {
    apiLink: string = 'api/Github/';

  constructor(private http: HttpClient) { }

  getRepositories(term: string) {
      return this.http.get<Repositories[]>(this.apiLink + 'search/' + term);
  }

  getLastResponsedRepositories() {
      return this.http.get<Repositories[]>(this.apiLink);
  }
}
