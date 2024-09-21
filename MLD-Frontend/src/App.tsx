import { Route, RouteProps, RouterProvider, createBrowserRouter, createRoutesFromElements } from "react-router-dom";
import { Suspense, lazy } from "react";
import AppContainer from "./components/app-container/AppContainer";
import Loader from "./components/Loader";
import LoginContainer from "./pages/authentication/LoginContainer";

const Logout = lazy(() => import("./pages/authentication/Logout"));
const Project = lazy(() => import("./pages/project/Project"));
const CreateProject = lazy(() => import("./pages/project/CreateProject"));
const Lexicology = lazy(() => import("./pages/project/lexicology/Lexicology"));
const PartOfSpeech = lazy(() => import("./pages/project/lexicology/part-of-speech/PartOfSpeech"));
const Dictionary = lazy(() => import("./pages/project/dictionary/Dictionary"));
const Lexeme = lazy(() => import("./pages/project/dictionary/Lexeme"));
const Library = lazy(() => import("./pages/project/library/Library"));
const TextEntry = lazy(() => import("./pages/project/library/TextEntry"));
const Home = lazy(() => import("./pages/Home"));
const ProjectList = lazy(() => import("./pages/project/ProjectList"));
const Login = lazy(() => import("./pages/authentication/Login"));
const SignIn = lazy(() => import("./pages/authentication/SignIn"));


const authenticationRoutes: RouteProps[] = [
  {
    element: <Suspense fallback={<Loader />}><Login /></Suspense>,
    path: "login"
  },
  {
    element: <Suspense fallback={<Loader />}><SignIn /></Suspense>,
    path: "signin"
  },
  {
    element: <Suspense fallback={<Loader />}><Logout /></Suspense>,
    path: "logout"
  },

]

const routeList: RouteProps[] = [
  {
    index: true,
    element: <Suspense fallback={<Loader />}><Home /></Suspense>
  },
  {
    element: <Suspense fallback={<Loader />}><ProjectList /></Suspense>,
    path: "my-projects"
  },
  {
    element:  <Suspense fallback={<Loader />}><ProjectList /></Suspense>,
    path: "projects"
  },
  {
    element:  <Suspense fallback={<Loader />}><CreateProject /></Suspense>,
    path: "new-project"
  },

]

const projectRoutes: RouteProps[] = [
  {
    element: <Suspense fallback={<Loader />}><Project /></Suspense>,
    path: ""
  },
  {
    element: <Suspense fallback={<Loader />}><Lexicology /></Suspense>,
    path: "lexicology"
  },
  {
    element:  <Suspense fallback={<Loader />}><PartOfSpeech /></Suspense>,
    path: "lexicology/:pos"
  },
  {
    element: <Suspense fallback={<Loader />}><Dictionary /></Suspense>,
    path: "dictionary"
  },
  {
    element:  <Suspense fallback={<Loader />}><Lexeme /></Suspense>,
    path: "dictionary/:lexeme"
  },
  {
    element: <Suspense fallback={<Loader />}><Library /></Suspense>,
    path: "library"
  },
  {
    element:  <Suspense fallback={<Loader />}><TextEntry /></Suspense>,
    path: "library/:text"
  },

]


const router = createBrowserRouter(
  createRoutesFromElements(
    <>
      <Route path="/auth" element={<LoginContainer />}>
        {mapRoutes(authenticationRoutes)}
      </Route>
      <Route path="/" element={<AppContainer />}>
        {mapRoutes(routeList)}
      </Route>
      <Route path="/:project" element={<AppContainer />}>
        {mapRoutes(projectRoutes)}
      </Route>

    </>
  )
)
function App() {
  return <><RouterProvider router={router} /></>
}


function mapRoutes(routes: RouteProps[]) {
  return routes.map(route => <Route key={route.path} {...route}/>)
}

export default App;