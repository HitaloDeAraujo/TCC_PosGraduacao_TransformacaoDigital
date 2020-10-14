import { Injectable } from '@angular/core';
import { Router, RouterStateSnapshot } from '@angular/router'

@Injectable({
    providedIn: 'root'
})

export class NavigationGuardService {
    constructor(private router: Router) { }

    canActivate(routerStateSnapshot: RouterStateSnapshot) {
        let result = true;

        let token = localStorage.getItem("TOKEN");

        if (token != null && !this.router.navigated) {
            if (routerStateSnapshot.url != "GestaoProcessoIndustrial")
                this.router.navigate(["/GestaoProcessoIndustrial"]);
        }
        else {
            result = this.router.navigated;

            if (!result && routerStateSnapshot.url != "/" && routerStateSnapshot.url.length != 0)
                this.router.navigate([""]);
            else
                result = true;
        }

        return result;
    }
}