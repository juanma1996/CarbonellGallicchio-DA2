import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { SessionBasicInfo } from 'src/app/models/session/session-basic-info';
import { SessionUserModel } from '../../models/session/session-user-model';
import { Guid } from 'guid-typescript';
import { map } from 'rxjs/operators';
import { BaseService } from '../base.service';

@Injectable({
    providedIn: 'root'
})
export class SessionService extends BaseService {
    private uri = environment.baseURL + 'sessions';
    private id = 1;
    private token: string;
    private currenUser: string;
    constructor(private http: HttpClient) {
        super();
        this.readToken();
    }

    getAll(): Observable<SessionBasicInfo[]> {
        return this.http.get<SessionBasicInfo[]>(this.uri)
            .pipe(catchError(this.handleError));
    }

    login(user: SessionUserModel) {

        const sessionData = {
            ...user,
        };
        this.currenUser = user.email;
        return this.http.post(
            `${this.uri}`,
            sessionData
        ).pipe(map(resp => { this.saveToken(resp['token']); return resp; }));
    }
    private saveToken(token: string) {
        this.token = token;
        localStorage.setItem('token', token.toString());
    }
    readToken() {
        if (localStorage.getItem('token')) {
            this.token = localStorage.getItem('token');
        } else {
            this.token = '';
        }
        return this.token;
    }
    isAuthenticated(): boolean {
        return this.token.length > 2;
    }
}
