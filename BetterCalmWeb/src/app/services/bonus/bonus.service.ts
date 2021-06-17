import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AudioContentModel } from 'src/app/models/audioContent/audio-content-model';
import { BaseService } from '../base.service';


@Injectable({
    providedIn: 'root'
})
export class BonusesService extends BaseService {
    private uri = environment.baseURL + 'bonuses';

    constructor(private http: HttpClient) {
        super();
    }

    get(): Observable<any[]> {
        let options = { headers: this.headers }
        var httpRequest = this.http.get<[any]>(this.uri, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }

    update(body): Observable<any> {
        let options = { headers: this.headers }
        var httpRequest = this.http.put<any>(this.uri, body, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }
}