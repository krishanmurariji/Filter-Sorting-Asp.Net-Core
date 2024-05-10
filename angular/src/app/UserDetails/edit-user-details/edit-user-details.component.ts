import { BsModalRef } from 'ngx-bootstrap/modal';
import { UserDetailsDto, UserDetailServiceServiceProxy } from '@shared/service-proxies/service-proxies';
import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';

@Component({
  selector: 'app-edit-user-details',
  templateUrl: './edit-user-details.component.html',
})
export class EditUserDetailsComponent implements OnInit{
  
  @Output () onSave = new EventEmitter <void> ();
  @Input() user: UserDetailsDto;
  editMode: boolean;
  saving = false;
  listUser : UserDetailsDto;
  usernamelist : any;
  genderlist : any ;
  maritalstatuslist : any ;
  constructor(
    private _Userdetails : UserDetailServiceServiceProxy,
    public bsModalRef: BsModalRef,
 
  ){}
  ngOnInit(): void {
    if (this.user) {
      debugger
      this.listUser = Object.assign({}, this.user);
      this.editMode = true;

    } 
    else {
      this.listUser = new UserDetailsDto();
      this.editMode = false;
    }
    this._Userdetails.getNames().subscribe((data)=>{
      this.usernamelist = data;
    })
    this._Userdetails.getGenders().subscribe((data)=>{
      this.genderlist = data;
    })
    this._Userdetails.getMaritalStatus().subscribe((data)=>{
      this.maritalstatuslist = data;
    })
  } 
 

  

  save(editUserForm: any) {
    if (!editUserForm.valid) {
      return;
    }
    this.saving = true;
  
    if (this.editMode) {
      debugger
      this._Userdetails.update(this.listUser).subscribe(
        () => {
          abp.notify.info('updated successfully');
          this.bsModalRef.hide();
          this.onSave.emit();
        },
        () => {
          this.saving = false;
          abp.notify.error('Failed to update');
        }
      );
    } else {
      
      this._Userdetails.create(this.listUser).subscribe(
        () => {
          abp.notify.info('Created successfully');
          this.bsModalRef.hide();
          this.onSave.emit();
        },
        () => {
          this.saving = false;
          abp.notify.error('Failed to Create');
        }
      );
    }
  }
}
