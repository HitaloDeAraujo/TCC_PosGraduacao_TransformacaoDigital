import { BaseService } from "./base.service";
import { Injectable } from "@angular/core";
import { LoginDTO } from "../DTOs/login.dto";

@Injectable()
export class UsuarioService {

    constructor(private baseService: BaseService) {
    }

    public Post(loginDTO : LoginDTO) {
        return this.baseService.post('gestaoprocessoindustrial/api/usuario', loginDTO);
    }
}