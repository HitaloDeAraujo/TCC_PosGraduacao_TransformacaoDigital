import { BaseService } from "./base.service";
import { Injectable } from "@angular/core";
import { RepositorioDTO } from "../DTOs/repositorio.dto";

@Injectable()
export class RepositorioService {

    constructor(private baseService: BaseService) {
    }

    public Get() {
        return this.baseService.get('gestaonormas/api/repositorio');
    }

    public Post(repositorioDTO : RepositorioDTO) {
        return this.baseService.post('gestaonormas/api/repositorio', repositorioDTO);
    }
}