import { Component , OnInit, Injector} from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { finalize } from 'rxjs';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { UserDetailsDto, UserDetailServiceServiceProxy, UserDetailsDtoPagedResultDto } from '@shared/service-proxies/service-proxies';
import { EditUserDetailsComponent } from '@app/UserDetails/edit-user-details/edit-user-details.component';


class PagedUserRequestDto extends PagedRequestDto{
  keyword :string;
}


@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  animations: [appModuleAnimation()]
})
export class UserDetailsComponent extends PagedListingComponentBase<UserDetailsDto> implements OnInit {
  listUser : UserDetailsDto [] = [];
  keyword = '';
  listUserName : any ;
  maritalstatuslist : any = [];
  emaillist : any = [];
  usernamelist: { [id: number]: string } = {};
  emailist: { [id: number]: string } = {};
  genderlist : any = [];

  selectedUserName: number | null = null;


  constructor(
    injector: Injector,
    private _modalService: BsModalService,
    private _Userdetails : UserDetailServiceServiceProxy,

  ){
    super(injector);
  }

  ngOnInit(): void {
    this._Userdetails.getNames().subscribe((data) => {
      this.listUserName = data;
    })
    

    this._Userdetails.getUserDetails().subscribe((data) => {
      debugger
      this.listUser = data;
    })

    
    this._Userdetails.getGenders().subscribe((data)=>{
      this.genderlist = data;
    })

    
    this._Userdetails.getMaritalStatus().subscribe((data)=>{
      this.maritalstatuslist = data;
    })
    this._Userdetails.getEmails().subscribe((data)=>{
      this.emaillist = data;
    })
    this.refresh()
    this.fetchName();
    this.fetchemail();
  }


  protected list(
    request: PagedUserRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._Userdetails
      .getAll(
        request.keyword,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: UserDetailsDtoPagedResultDto ) => {
        this.listUser = result.items;
        this.showPaging(result, pageNumber);    
      });
  }
 

  fetchName() {  
    this._Userdetails.getNames().subscribe((c) => {
      debugger; 
      this.usernamelist = c.reduce((obj, u) => {
        obj[u.value] = u.name;
        return obj;
      }, {});
    });
  }
  getName(id: number): string {
    return this.usernamelist[id] || '';
  }
  
  fetchemail() {  
    this._Userdetails.getEmails().subscribe((c) => {
      debugger; 
      this.emailist = c.reduce((obj, u) => {
        obj[u.value] = u.name;
        return obj;
      }, {});
    });
  }

  getemail(id: number): string {
    return this.emailist[id] || '';
  }
  
  protected delete(user: UserDetailsDto){
    abp.message.confirm(
      this.l('Delete Warning Message', user.fatherName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._Userdetails.delete(user.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

  createUser(): void {
    this.showCreateOrEditUserDialog();
  }

  editUser(user: UserDetailsDto): void {
    this.showCreateOrEditUserDialog(user);
  }


  private showCreateOrEditUserDialog(user?:UserDetailsDto): void {
    let createOrEditUserDialog: BsModalRef;
    if (!user) {
      createOrEditUserDialog = this._modalService.show(
        EditUserDetailsComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditUserDialog = this._modalService.show(
        EditUserDetailsComponent,
        {
          class: 'modal-lg',
          initialState: {
            user: user, 
            editMode: true
          },
        }
      );
    }


    createOrEditUserDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
  




}
