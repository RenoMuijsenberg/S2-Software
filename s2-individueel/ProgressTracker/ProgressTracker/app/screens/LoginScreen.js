import React, {useContext, useState} from 'react';
import {ImageBackground, Text, SafeAreaView, TouchableHighlight, View, Alert} from 'react-native';
import {StatusBar} from "expo-status-bar";
import {useForm } from "react-hook-form";
import Input from "../components/Input"
import AsyncStorage from '@react-native-async-storage/async-storage';
import axios from "../Axios";
import styles from "../styles/Main.styles"

function LoginScreen({ navigation, props }) {
    const {control, handleSubmit, formState: { errors } } = useForm();

    const LoginUser = async (data) => {
        await axios.post("user/login", JSON.stringify(data)).then(async response => {
            if (response.data.token !== "") {
                await AsyncStorage.setItem(
                    '@JwtToken',
                    response.data.token
                );
                props.SetJwtToken(response.data.token);
                await AsyncStorage.setItem(
                    '@JwtTokenExpire',
                    response.data.expiration
                );
                props.SetJwtTokenExpire(response.data.token);
                await AsyncStorage.setItem(
                    '@UserId',
                    response.data.userId
                );
                navigation.navigate("Workout")
            } else {
                Alert.alert("Error", response.exception);
            }
        });
    };

    return (
        <SafeAreaView style={styles.flexOne}>
            <StatusBar style="light"/>
            <ImageBackground source={{uri: "https://i.imgur.com/C5SFse9.jpeg"}} style={styles.image}>
                <View style={styles.quoteContainer}>
                    <View style={styles.background}>
                        <Text style={styles.headerTextCenter}>LOGIN</Text>
                        <Input label={"Email"} name="Email" type="email" control={control} style={styles.test}/>
                        {errors.Email && <Text style={styles.error}>{errors.Email.message}</Text>}
                        <Input label={"Password"} name="Password" type="password" control={control} style={styles.test}/>
                        {errors.Password && <Text style={styles.error}>{errors.Password.message}</Text>}
                    </View>
                </View>
                <View>
                    <TouchableHighlight style={styles.buttonOutline} onPress={handleSubmit(LoginUser)}>
                        <Text style={styles.buttonText}>Login</Text>
                    </TouchableHighlight>
                </View>
            </ImageBackground>
        </SafeAreaView>
    );
}

export default LoginScreen;