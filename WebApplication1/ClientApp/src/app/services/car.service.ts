import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { tap, catchError } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';

@Injectable()
export class CarService {

  messageService: any;
  private resourceUrl = 'api/Car';

  constructor(private http: Http) { }

  create(answer: any): Observable<any> {
    const copy = this.convert(answer);
    return this.http.post(this.resourceUrl, copy).map((res: Response) => {
      return res.json();
    });
  }

  update(template: any): Observable<any> {
    const copy = this.convert(template);
    return this.http.put(`${this.resourceUrl}/${template.answerId}`, copy).map((res: Response) => {
      return res.json();
    });
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
