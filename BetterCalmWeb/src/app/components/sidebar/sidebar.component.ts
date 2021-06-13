import { Component, OnInit } from "@angular/core";

export interface RouteInfo {
  path: string;
  title: string;
  type: string;
  icontype: string;
  collapse?: string;
  isCollapsed?: boolean;
  isCollapsing?: any;
  children?: ChildrenItems[];
}

export interface ChildrenItems {
  path: string;
  title: string;
  smallTitle?: string;
  rtlSmallTitle?: string;
  type?: string;
  collapse?: string;
  children?: ChildrenItems2[];
  isCollapsed?: boolean;
}
export interface ChildrenItems2 {
  path?: string;
  smallTitle?: string;
  rtlSmallTitle?: string;
  title?: string;
  type?: string;
}
//Menu Items
export const ROUTES: RouteInfo[] = [
  {
    path: "/login",
    title: "Login",
    type: "link",
    icontype: "tim-icons icon-key-25",
  },
  {
    path: "/categories",
    title: "Content by category",
    type: "sub",
    icontype: "tim-icons icon-headphones",
    collapse: "",
    isCollapsed: true,
    children: [

      {
        path: "audioContents",
        rtlSmallTitle: "ع ",
        title: "Audios",
        type: "link",
        smallTitle: "P"
      },
      {
        path: "videoContents",
        rtlSmallTitle: "ع ",
        title: "Videos",
        type: "link",
        smallTitle: "P"
      },
    ]
  },
  {
    path: "/consultation",
    title: "Consultation",
    type: "link",
    icontype: "tim-icons icon-calendar-60",
  },
  {
    path: "/contentImporter",
    title: "Content importer",
    type: "link",
    icontype: "tim-icons icon-cloud-upload-94",
  },
  {
    path: "/administrator",
    title: "Administrators",
    type: "sub",
    icontype: "tim-icons icon-single-02",
    collapse: "",
    isCollapsed: true,
    children: [

      {
        path: "create",
        rtlSmallTitle: "ع ",
        title: "Register administrator",
        type: "link",
        smallTitle: ""
      },
      {
        path: "maintenance",
        rtlSmallTitle: "ع ",
        title: "Administrators maintance",
        type: "link",
        smallTitle: ""
      },
    ]
  },
  {
    path: "/psychologist",
    title: "Psychologists",
    type: "sub",
    icontype: "tim-icons icon-badge",
    collapse: "",
    isCollapsed: true,
    children: [

      {
        path: "create",
        rtlSmallTitle: "ع ",
        title: "Register psychologist",
        type: "link",
        smallTitle: ""
      },
      {
        path: "maintenance",
        rtlSmallTitle: "ع ",
        title: "Psychologist maintance",
        type: "link",
        smallTitle: ""
      },
    ]
  },
  {
    path: "",
    title: "Administrate content",
    type: "sub",
    icontype: "tim-icons icon-settings",
    collapse: "",
    isCollapsed: true,
    children: [
      {
        path: "audioContent",
        rtlSmallTitle: "ع ",
        title: "Create Audio Content",
        type: "link",
        smallTitle: "P"
      },
      {
        path: "videoContent",
        rtlSmallTitle: "ع ",
        title: "Create Video Content",
        type: "link",
        smallTitle: "P"
      },
    ]
  },
  {
    path: "/bonus",
    title: "Bonuses",
    type: "link",
    icontype: "tim-icons icon-money-coins",
  },
];

@Component({
  selector: "app-sidebar",
  templateUrl: "./sidebar.component.html",
  styleUrls: ["./sidebar.component.css"]
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor() { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
}
