import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AdministratorFormComponent } from 'src/app/pages/administrator/administrator-form/administrator-form.component';
import { AdministratorModel } from 'src/app/models/administrator/administrator-basic-info';
import { BaseService } from '../base.service';


@Injectable({
    providedIn: 'root'
})
export class AdministratorService extends BaseService {
    private uri = environment.baseURL + 'administrators';

    constructor(private http: HttpClient) {
        super();
    }

    add(body) {
        let options = { headers: this.headers };
        var httpRequest = this.http.post(this.uri, body, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }

    get(): Observable<[AdministratorModel]> {
        let options = { headers: this.headers };
        var httpRequest = this.http.get<[AdministratorModel]>(this.uri, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }

    getAdministrator(id): Observable<AdministratorModel> {
        let options = { headers: this.headers };
        var httpRequest = this.http.get<AdministratorModel>(this.uri + '/' + id, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }

    update(body): Observable<AdministratorModel> {
        let options = { headers: this.headers };
        var httpRequest = this.http.put<AdministratorModel>(this.uri, body, options)
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