import { BaseService } from "./base.service";
import { Injectable } from "@angular/core";

@Injectable()
export class RepositorioService {

    constructor(private baseService: BaseService) {
    }

    public Get() {
        return this.baseService.get('gestaonormas/api/repositorio');
    }
}