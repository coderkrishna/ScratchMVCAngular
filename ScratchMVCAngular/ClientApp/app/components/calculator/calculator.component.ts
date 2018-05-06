import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'calculator',
    templateUrl: './calculator.component.html'
})
export class CalculatorComponent {
    public basicStats: Statistic;

    constructor(public http: Http) { }

    public getStats(inputData: string): void {
        //alert("Clicked Me!");
        var baseUrl = "http://localhost:58904/";
        this.http.get(baseUrl + 'api/Calculator/Calculate/' + inputData).subscribe(result => {
            this.basicStats = result.json() as Statistic;
            console.debug(this.basicStats);
        }, error => console.error(error));
    }

    obj = 'Hello';
}

interface Statistic {
    mean: number;
    median: number;
    mode: number[];
    status: string; 
    statusDesc: string;
}
