import React from 'react';
import {
    ImageBackground,
    Text,
    SafeAreaView,
    TouchableHighlight,
    View,
    Alert
} from 'react-native';
import {StatusBar} from "expo-status-bar";
import {useForm } from "react-hook-form";
import Input from "../components/Input"
import axios from "../Axios";
import styles from "../styles/Main.styles"



function RegisterScreen({ navigation }) {
    const {control, handleSubmit, formState: { errors } } = useForm();
    
    const RegisterUser = async (data) => {
        await axios.post("user/register", JSON.stringify(data)).then(response => {
            if (response.data.success === true) {
                Alert.alert("Success", response.data.userMessage);
                navigation.navigate("Login");
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
                        <Text style={styles.headerTextCenter}>REGISTER</Text>
                        <Input label={"Email"} name="Email" type="email" control={control} style={styles.test}/>
                        {errors.Email && <Text style={styles.error}>{errors.Email.message}</Text>}
                        <Input label={"Password"} name="Password" type="password" control={control} style={styles.test}/>
                        {errors.Password && <Text style={styles.error}>{errors.Password.message}</Text>}
                        <Input label={"Confirm password"} name="ConfirmPassword" type="password" control={control} style={styles.test}/>
                        {errors.ConfirmPassword && <Text style={styles.error}>{errors.ConfirmPassword.message}</Text>}
                    </View>
                </View>
                <View>
                    <TouchableHighlight style={styles.buttonOutline} onPress={handleSubmit(RegisterUser)}>
                        <Text style={styles.buttonText}>Register</Text>
                    </TouchableHighlight>
                </View>
            </ImageBackground>
        </SafeAreaView>
    );
}

export default RegisterScreen;