import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DepartmentService } from '../../../services/department.service';

@Component({
  selector: 'app-update-department-modal',
  templateUrl: './update-department-modal.component.html',
  styleUrls: ['./update-department-modal.component.css']
})
export class UpdateDepartmentModalComponent implements OnInit {

  @Input() modal_name:string;
  @Input() data;
  department:FormGroup;

  constructor(private builder:FormBuilder,private deptService:DepartmentService) { }

  ngOnInit() {
    this.department = this.builder.group({
      ID: this.data['ID'],
      Name:[this.data['Name'],Validators.required]
    })
  }

  update(){
    if(this.department.controls.Name.invalid)
      return;

    this.deptService.update(this.department.value).subscribe(
      (success)=>{
        location.href = `/departments/${this.data['ID']}`
      },
      (error)=>{
        console.log(error);
      }
    )
  }

}
