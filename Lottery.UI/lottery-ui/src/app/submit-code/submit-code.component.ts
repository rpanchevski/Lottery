import { Component, OnInit } from '@angular/core';
import { UserCode, Code } from './submit-code.model';
import { CodeService } from './submit-code.service';

@Component({
  selector: 'app-submit-code',
  templateUrl: './submit-code.component.html',
  styleUrls: ['./submit-code.component.css']
})
export class SubmitCodeComponent implements OnInit {
  userCode: UserCode = {} as UserCode;

  constructor(private codeService: CodeService) { 
    this.userCode.code = {} as Code;
  }

  submit() {
    this.codeService.submitCode(this.userCode).subscribe((result) => {
      debugger;
    },
    (error) => {
      debugger;
    })
  }

  ngOnInit() {
  }

}
