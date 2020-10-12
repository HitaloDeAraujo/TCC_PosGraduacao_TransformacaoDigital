import { BaseService } from "./base.service";
import { Injectable } from "@angular/core";

@Injectable()
export class ParceiroService {

    constructor(private baseService: BaseService) {
    }

    public Get() {
        return this.baseService.get('assessoriasconsultorias/api/parceiro');
    }
}