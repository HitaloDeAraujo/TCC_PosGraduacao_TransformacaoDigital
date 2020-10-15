import { BaseService } from "./base.service";
import { Injectable } from "@angular/core";

@Injectable()
export class EventoService {

    constructor(private baseService: BaseService) {
    }

    public Get() {
        return this.baseService.get('gestaoprocessoindustrial/api/evento');
    }

    public ObterRelacaoOrcamentosVendas() {
        return this.baseService.get('gestaoprocessoindustrial/api/evento/tipoEvento/maisRecente/' + 4);
    }
}