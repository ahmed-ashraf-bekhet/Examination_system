import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DepartmentService } from '../../../services/department.service';

@Component({
  selector: 'app-add-department-modal',
  templateUrl: './add-department-modal.component.html',
  styleUrls: ['./add-department-modal.component.css']
})
export class AddDepartmentModalComponent implements OnInit {
  @Input() modal_name:string;
  department:FormGroup;

  constructor(private builder:FormBuilder,private deptService:DepartmentService) { }

  ngOnInit() {
    this.department = this.builder.group({
      Name:['',Validators.required]
    })
  }

  save(){
    if(this.department.controls.Name.invalid)
      return;

    this.deptService.save(this.department.value).subscribe(
      (success)=>{
        console.log(success);
        alert("You Added New Department successfully , Thanks");
      },
      (error)=>{
        console.log(error);
        alert("Some Thing Wrong , Please Try Again ..");
      }
    )
  }

}
