import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PsychologistBasicInfo } from 'src/app/models/psychologist/psychologist-basic-info';
import { BaseService } from '../base.service';

@Injectable({
    providedIn: 'root'
})
export class PsychologistService extends BaseService {
    private uri = environment.baseURL + 'psychologists';
    constructor(private http: HttpClient) {
        super();
    }

    add(body): Observable<PsychologistBasicInfo> {
        let options = { headers: this.headers };
        var httpRequest = this.http.post<PsychologistBasicInfo>(this.uri, body, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }

    get(): Observable<[PsychologistBasicInfo]> {
        let options = { headers: this.headers };
        var httpRequest = this.http.get<[PsychologistBasicInfo]>(this.uri, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }

    getPsychologist(id): Observable<PsychologistBasicInfo> {
        let options = { headers: this.headers };
        var httpRequest = this.http.get<PsychologistBasicInfo>(this.uri + '/' + id, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }

    update(body): Observable<PsychologistBasicInfo> {
        let options = { headers: this.headers };
        var httpRequest = this.http.put<PsychologistBasicInfo>(this.uri, body, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }

    delete(id): Observable<any> {
        let options = { headers: this.headers };
        var httpRequest = this.http.delete<any>(this.uri + "/" + id, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }
}