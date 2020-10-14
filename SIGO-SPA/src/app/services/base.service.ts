import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable()
export class BaseService {

    private readonly API: string;

    constructor(private http: HttpClient) {
        this.API = environment.API;
    }

    public get(endPoint: string) {

        var options = this.createRequestOptions();

        return this.http.get(this.API + endPoint, options);
    }

    public post(endPoint: string, data: any) {

        let options = this.createRequestOptions();
        let body = JSON.stringify(data);

        return this.http.post<any>(this.API + endPoint, body, options);
    }

    public createRequestOptions(params?: HttpParams) {

        let token = localStorage.getItem('TOKEN');

        let options =
        {
            headers: new HttpHeaders().set('Content-Type', 'application/json').set('Authorization', `Bearer ${token}`),
            params: params
        }

        return options;
    }

    public auth(user: string, password: string) {

        let body = `grant_type=password&user=${user}&password=${password}`;

        var options = this.createRequestOptions();

        return this.http.post(this.API, body, options);
    }

    public token(endPoint: string, data: any) {

        let options =
        {
            headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded')
        }

        return this.http.post<any>(this.API + endPoint, data, options);
    }
}