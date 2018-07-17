import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { tap, catchError } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';

@Injectable()
export class CarsService {

  messageService: any;
  private resourceUrl = 'api/Car';

  constructor(private http: Http) { }

  /** GET CAR by id. Will 404 if id not found */
  getCar(id: number): Observable<any> {
    const url = `${this.resourceUrl}/${id}`;
    return this.http.get(url).pipe(
      tap(_ => this.log(`fetched hero id=${id}`)),
      catchError(this.handleError<any>(`getHero id=${id}`))
    );
  }

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

  /**
  * Handle Http operation that failed.
  * Let the app continue.
  * @param operation - name of the operation that failed
  * @param result - optional value to return as the observable result
  */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** Log a HeroService message with the MessageService */
  private log(message: string) {
    this.messageService.add('HeroService: ' + message);
  }
}
