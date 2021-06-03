import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AdministratorFormComponent } from 'src/app/pages/administrator/administrator-form/administrator-form.component';
import { AdministratorModel } from 'src/app/models/administrator/administrator-basic-info';


@Injectable({
    providedIn: 'root'
})
export class AdministratorService {
    private uri = environment.baseURL + 'administrators';
    constructor(private http: HttpClient) { }

    add(body) {
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        });
        let options = { headers: headers };
        var httpRequest = this.http.post(this.uri, body, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }

    getAdministrator(id): Observable<AdministratorModel> {
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        });
        let options = { headers: headers }
        var httpRequest = this.http.get<AdministratorModel>(this.uri + '/' + id, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }

    update(body): Observable<AdministratorModel> {
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        });
        let options = { headers: headers };
        var httpRequest = this.http.put<AdministratorModel>(this.uri, body, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }

    delete(id): Observable<any> {
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        });
        let options = { headers: headers };
        var httpRequest = this.http.delete<any>(this.uri + "/" + id, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }

    private handleError(error: HttpErrorResponse) {
        return throwError(error.error);
    }
}