import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Card} from './Classes/Card';

@Injectable({
  providedIn: 'root'
})
export class WebApiServiceService {

  constructor(private http: HttpClient) { }

  getResponse(request: string) {
    return this.http.get<Card[]>('api/Github/search/' + request);
  }

  getLastRequest() {
    return this.http.get<Card[]>('api/Github/');
  }
}
