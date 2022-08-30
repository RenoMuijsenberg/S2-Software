import * as React from 'react';
import {NavigationContainer} from '@react-navigation/native';
import {createNativeStackNavigator} from '@react-navigation/native-stack';
import AsyncStorage from "@react-native-async-storage/async-storage";
import { useEffect, useState} from "react";

//Screen variables
import Home from "./app/screens/HomeScreen";
import Register from "./app/screens/RegisterScreen";
import Login from "./app/screens/LoginScreen";
import Schemes from "./app/screens/SchemesScreen";
import CreateScheme from "./app/screens/CreateSchemeScreen";
import Scheme from "./app/screens/SchemeScreen";
import CreateExercise from "./app/screens/CreateExerciseScreen"
import WorkoutScreen from "./app/screens/WorkoutScreen";
import UpdateExercise from "./app/screens/UpdateExerciseScreen";

const Stack = createNativeStackNavigator();

function App() {
    const [jwtToken, setJwtToken] = useState("");
    const [tokenExpire, setTokenExpire] = useState("");

    const SetJwtToken = async (data) => {
        setJwtToken(data);
    }

    const SetJwtTokenExpire = async (data) => {
        setTokenExpire(data);
    }
    
    const GetJwtToken = async () => {
        await AsyncStorage.getItem('@JwtToken').then(data => {
            SetJwtToken(data);
        });
        await AsyncStorage.getItem('@JwtTokenExpire').then(data => {
            SetJwtTokenExpire(data);
        });
    }

    useEffect(async () => {
        await GetJwtToken();
    }, []);
    
    if (jwtToken === "" || jwtToken == null || tokenExpire < Date.now()) {
        return (
            <NavigationContainer>
                <Stack.Navigator screenOptions={{
                    headerStyle: {
                        backgroundColor: '#14213D',
                    },
                    headerTintColor: '#fff',
                    headerShadowVisible: false
                }}>
                    <Stack.Screen name="Home" component={Home}/>
                    <Stack.Screen name="Register" component={Register}/>
                    <Stack.Screen name="Login" component={Login} SetJwtToken={SetJwtToken} SetJwtTokenExpire={SetJwtTokenExpire}/>
                </Stack.Navigator>
            </NavigationContainer>
        );
    }
    return (
        <NavigationContainer>
            <Stack.Navigator screenOptions={{
                headerStyle: {
                    backgroundColor: '#14213D',
                },
                    headerTintColor: '#fff',
                    headerShadowVisible: false
                }}>
                {/*Logged in section*/}
                <Stack.Screen name="Schemes" component={Schemes} />
                <Stack.Screen name="Create scheme" component={CreateScheme} />
                <Stack.Screen name="Scheme" component={Scheme} />
                <Stack.Screen name="Create exercise" component={CreateExercise} />
                <Stack.Screen name="Workout" component={WorkoutScreen} />
                <Stack.Screen name="Update exercise" component={UpdateExercise} />
            </Stack.Navigator>
        </NavigationContainer>
    )
}

export default App;