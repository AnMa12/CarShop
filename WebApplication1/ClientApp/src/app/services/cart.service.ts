import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';


@Injectable()
export class CartsService {

  private resourceUrl = 'api/Cart';

  constructor(private http: Http) { }

  create(answer: any): Observable<any> {
    const copy = this.convert(answer);
    return this.http.post(this.resourceUrl, copy);
  }

  update(template: any, id): Observable<any> {
    const copy = this.convert(template);
    return this.http.put(`${this.resourceUrl}/${id}`, copy);
  }

  find(id: string): Observable<any> {
    return this.http.get(`${this.resourceUrl}/${id}`);
  }

  query(req?: any): Observable<any> {
    return this.http.get(this.resourceUrl, req);
  }

  delete(id: number): Observable<Response> {
    return this.http.delete(`${this.resourceUrl}/${id}`);
  }

  private convertResponse(res: Response): any {
    const jsonResponse = res.json();
    return jsonResponse;
  }

  private convert(template: any): any {
    const copy: any = Object.assign({}, template);
    return copy;
  }
}
