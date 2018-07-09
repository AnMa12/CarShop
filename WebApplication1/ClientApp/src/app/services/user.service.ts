import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';


@Injectable()
export class PaymentsService {

  private resourceUrl = 'api/User';

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

  find(id: number): Observable<any> {
    return this.http.get(`${this.resourceUrl}/${id}`).map((res: Response) => {
      return res.json();
    });
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
